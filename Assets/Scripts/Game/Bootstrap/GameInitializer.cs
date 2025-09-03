using System.Collections.Generic;
using Game.Application.Interfaces;
using Game.Application.UseCases;
using Game.Domain.Entities;
using Game.Presentation;
using Game.Presentation.Presenters;
using Game.Presentation.Views;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Bootstrap
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private CardView cardViewPrefab;

        [Range(2, 6)] [SerializeField] private int rowCount;
        [Range(2, 4)] [SerializeField] private int columnCount;

        [Range(1, 4)] [SerializeField] private float spaceBetweenCards;

        private IGameplayListener _gameplayListener;
        private ISaveService _saveService;

        public void Init(IGameplayListener gameplayListener, ISaveService saveService)
        {
            _gameplayListener = gameplayListener;
            _saveService = saveService;
        }

        private void Initialize()
        {
            //Debug.Log(_gameplayListener.GetMessage());
            var cardViews = new List<CardView>();
            var cardMatchUseCase = new CardMatchUseCase(rowCount * columnCount / 2,
                (IGameEndListener)_gameplayListener,
                (ICardMatchListener)_gameplayListener,
                (ITurnCompleteListener)_gameplayListener);
            // Card Creation Logic
            var ratio = spaceBetweenCards / 2;
            var startX = -((columnCount - 1) * ratio);
            var startY = -((rowCount - 1) * ratio);
            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < rowCount; j++)
                {
                    // Instantiate CardView
                    var cardView = Instantiate(cardViewPrefab,
                        new Vector3(startX + i * spaceBetweenCards, startY + j * spaceBetweenCards, 0),
                        Quaternion.identity);
                    // Create Card Entity and UseCase
                    var card = new CardEntity();
                    var cardUseCase = new CardUseCase(card);
                    // Create presenter with a shared use case
                    var presenter = new CardPresenter(cardView, card, cardUseCase, cardMatchUseCase);
                    // Initialize view with presenter
                    cardView.Initialize(presenter);
                    //
                    cardViews.Add(cardView);
                }
            }

            // Initialize Card Symbol
            var cardSymbols = new int[cardViews.Count];
            var halfLength = cardViews.Count / 2;
            for (var i = 0; i < halfLength; i++)
            {
                cardSymbols[i] = i;
                cardSymbols[i + halfLength] = i;
            }

            // Shuffle Symbols
            for (var i = 0; i < cardSymbols.Length; i++)
            {
                var randomIndex = Random.Range(0, cardSymbols.Length);
                (cardSymbols[i], cardSymbols[randomIndex]) = (cardSymbols[randomIndex], cardSymbols[i]);
            }

            // Initialize Cards
            for (var i = 0; i < cardSymbols.Length; i++)
            {
                cardViews[i].UpdateCartID(cardSymbols[i]);
            }
        }

        //private StartGameUseCase _startGameUseCase;

        // For Testing Purpose Only
        private void Awake_1()
        {
            //var gameplaySetup = new GameplaySetup();
            //_startGameUseCase = new StartGameUseCase(gameplaySetup);
            var gameModeConfig = _saveService.LoadGameMode();
            //_startGameUseCase.Execute(gameMode);
            rowCount = gameModeConfig.RowCount;
            columnCount = gameModeConfig.ColumnCount;
            Initialize();
        }

        private void HandleLoadComplete()
        {
            Debug.Log(">>>>> Load Complete");
            //var gameplaySetup = new GameplaySetup();
            //_startGameUseCase = new StartGameUseCase(gameplaySetup);
            var gameModeConfig = _saveService.LoadGameMode();
            //_startGameUseCase.Execute(gameMode);
            rowCount = gameModeConfig.RowCount;
            columnCount = gameModeConfig.ColumnCount;
            Initialize();
        }

        private void OnEnable()
        {
            LoadingManager.OnLoadComplete += HandleLoadComplete;
        }

        private void OnDisable()
        {
            LoadingManager.OnLoadComplete -= HandleLoadComplete;
        }
    }
}