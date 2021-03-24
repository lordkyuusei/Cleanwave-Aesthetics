using AutoMapper;
using Cleanwave.Application.Common.Interfaces;
using Cleanwave.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cleanwave.Application.UseCases.Songs.Commands.GetSong
{
    class GetSongQuery : IRequest<SongDTO>
    {
        public int Id { get; set; }
    }

    class GetSongQueryHandler : IRequestHandler<GetSongQuery, SongDTO>
    {
        private readonly IMapper mapper;
        private readonly ICleanwaveDbContext context;

        public GetSongQueryHandler(IMapper mapper, ICleanwaveDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public Task<SongDTO> Handle(GetSongQuery request, CancellationToken cancellationToken)
        {
            CHILLWAVE_SONG song = context.ChillwaveSongs.Find(request.Id);
            return Task.FromResult(mapper.Map<SongDTO>(song));
        }
    }
}
