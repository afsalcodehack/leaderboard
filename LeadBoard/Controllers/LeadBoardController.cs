using LeadBoard.Entity;
using LoadBoard.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadBoard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadBoardController: ControllerBase
    {
        private IGame _gameService;
        private IGameUser _userSerivce;
        private IGameScoreBoard _scoreService;
        public LeadBoardController(IGame game, IGameUser gameUser, IGameScoreBoard gameScoreBoard)
        {
            _gameService = game;
            _userSerivce = gameUser;
            _scoreService = gameScoreBoard;
        }

        [HttpGet("GetAllGames")]
        public async Task<GameResponse> GetAllGames()
        {
           return await _gameService.GetAllGames();
        }

        [HttpPost("CreateGame")]
        public async Task<ResponseBase> CreateGame(GameModel game)
        {
            return await _gameService.CreateGame(game);
        }


        [HttpGet("GetAllUsers")]
        public async Task<UserResponse> GetAllUsers()
        {
            return await _userSerivce.GetAllUser();
        }

        [HttpPost("CreateUser")]
        public async Task<ResponseBase> CreateUser(UserModel user)
        {
            return await _userSerivce.CreateUser(user);
        }

        [HttpGet("GetScore")]
        public async Task<ScoreBoardResponse> GetScore(int limit)
        {
            return await _scoreService.GetScore(limit);
        }

        [HttpGet("GetScoreByGame")]
        public async Task<ScoreBoardResponse> GetScoreByGame(int gameId)
        {
            return await _scoreService.GetByGame(gameId);
        }

        [HttpPost("CreateScore")]
        public async Task<ResponseBase> CreateScore(ScoreBoardModel score)
        {
            return await _scoreService.CreateScore(score);
        }
    }
}
