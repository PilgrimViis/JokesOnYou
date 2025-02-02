﻿using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using AutoMapper;

namespace JokesOnYou.Web.Api.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tagRepo = tagRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TagReplyDto> CreateTagAsync(TagCreateDto tagCreateDto, string userId)
        {
            var tag = _mapper.Map<Tag>(tagCreateDto);
            tag.OwnerId = userId;  
            await _tagRepo.CreateTagAsync(tag);

            var saved = await _unitOfWork.SaveAsync();
            if (!saved)
            {
                throw new AppException($"error saving {tagCreateDto.Name}"); 
            }

            var tagReplyDto = _mapper.Map<TagReplyDto>(tag);

            return tagReplyDto;
        }

        public async Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync() => await _tagRepo.GetAllTagDtosAsync();
        public async Task<TagReplyDto> GetTagDtoAsync(int id) => await _tagRepo.GetTagDtoAsync(id);

        public async Task<Tag> GetTagAsync(int id)
        {
            var tag = await _tagRepo.GetTagAsync(id);

            if (tag == null)
            {
                throw new AppException($"No Tag with Id:\"{id}\" has been found.");
            }
            return tag;
        }

        /// <summary>
        /// Deletes given <paramref name="tag"/>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task DeleteTagAsync(Tag tag)
        {
            _tagRepo.Delete(tag);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException($"Something wend wrong when trying to save the database after Deleting the Tag: {tag}");
            }
        }

    }
}
