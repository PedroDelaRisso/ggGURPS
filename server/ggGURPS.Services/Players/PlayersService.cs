using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class PlayersService : IPlayersService
{
    private readonly ApplicationDbContext _context;

    public PlayersService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(PostPlayerDTO playerDTO)
    {
        var player = new Player(playerDTO.Id, playerDTO.Name);
        _context.Players.Add(player);
        await this.Save();
    }

    public async Task<List<GetPlayersDTO>> GetAll()
    {
        var playersList = await _context.Players.ToListAsync();
        if (!playersList.Any())
            throw new Exception("There are no saved Players!");

        var playersListDTO = new List<GetPlayersDTO>();
        foreach(Player p in playersList)
        {
            playersListDTO.Add(new GetPlayersDTO(p.Id, p.Name));
        }

        return playersListDTO;
    }

    public async Task<GetPlayerByIdDTO> GetById(long id)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);

        if(player == null)
            throw new KeyNotFoundException();

        var playerDTO = new GetPlayerByIdDTO(player.Id, player.Name);
        foreach(Character c in player.Characters)
        {
            playerDTO.Characters.Add(new GetCharactersDTO(c.Id, c.Name));
        }

        return playerDTO;
    }

    public async Task Update(PutPlayerDTO playerDTO)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == playerDTO.Id);
        if(player == null)
            throw new KeyNotFoundException();

        player.Name = playerDTO.Name;
        _context.Players.Update(player);

        await this.Save();
    }

    public async Task Delete(long id)
    {
        var player = await _context.Players.FirstOrDefaultAsync(p => p.Id == id);
        if(player == null)
            throw new KeyNotFoundException();
        
        _context.Players.Remove(player);
        await this.Save();
    }

    private async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}