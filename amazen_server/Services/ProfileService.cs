using System;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
    public class ProfileService
    {
    private readonly ProfileRepository _profileRepository;

    public ProfileService(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public Profile GetOrCreateProfile(Profile userInfo)
        {
            Profile profile = _profileRepository.GetByEmail(userInfo.Email);
            if (profile == null || profile.Id == null)
            {
                return _profileRepository.Create(userInfo);
            }
            return profile;
        }
    }
}