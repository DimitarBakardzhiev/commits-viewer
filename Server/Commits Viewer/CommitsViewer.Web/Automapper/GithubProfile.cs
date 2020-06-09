namespace CommitsViewer.Web.Automapper
{
    using AutoMapper;
    using CommitsViewer.Models.Github;
    using CommitsViewer.ViewModels;

    public class GithubProfile : Profile
    {
        public GithubProfile()
        {
            CreateMap<CommitWrapper, CommitVM>()
                .ForMember(dest => dest.Sha, opt => opt.MapFrom(src => src.sha))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.commit.author.email))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.commit.author.date))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.commit.message));

            CreateMap<UserItem, UserVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.login));

            CreateMap<RepositoryItem, RepositoryVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.owner.login));
        }
    }
}
