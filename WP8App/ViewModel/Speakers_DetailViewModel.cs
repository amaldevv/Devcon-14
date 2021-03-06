// ------------------------------------------------------------------------
// ========================================================================
// THIS CODE AND INFORMATION ARE GENERATED BY AUTOMATIC CODE GENERATOR
// ========================================================================
// Template:   	ViewModel.tt
// Version:		2.0
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Controls = WPAppStudio.Controls;
using Entities = WPAppStudio.Entities;
using EntitiesBase = WPAppStudio.Entities.Base;
using IServices = WPAppStudio.Services.Interfaces;
using IViewModels = WPAppStudio.ViewModel.Interfaces;
using Localization = WPAppStudio.Localization;
using Repositories = WPAppStudio.Repositories;
using Services = WPAppStudio.Services;
using ViewModelsBase = WPAppStudio.ViewModel.Base;
using WPAppStudio;
using WPAppStudio.Shared;

namespace WPAppStudio.ViewModel
{
    /// <summary>
    /// Implementation of Speakers_Detail ViewModel.
    /// </summary>
    [CompilerGenerated]
    [GeneratedCode("Radarc", "4.0")]
    public partial class Speakers_DetailViewModel : ViewModelsBase.VMBase, IViewModels.ISpeakers_DetailViewModel, ViewModelsBase.INavigable
    {       

		private readonly Repositories.Speakers_SpeakersDS _speakers_SpeakersDS;
		private readonly IServices.IDialogService _dialogService;
		private readonly IServices.INavigationService _navigationService;
		private readonly IServices.ISpeechService _speechService;
		private readonly IServices.IShareService _shareService;
		private readonly IServices.ILiveTileService _liveTileService;
		
        /// <summary>
        /// Initializes a new instance of the <see cref="Speakers_DetailViewModel" /> class.
        /// </summary>
        /// <param name="speakers_SpeakersDS">The Speakers_ Speakers D S.</param>
        /// <param name="dialogService">The Dialog Service.</param>
        /// <param name="navigationService">The Navigation Service.</param>
        /// <param name="speechService">The Speech Service.</param>
        /// <param name="shareService">The Share Service.</param>
        /// <param name="liveTileService">The Live Tile Service.</param>
        public Speakers_DetailViewModel(Repositories.Speakers_SpeakersDS speakers_SpeakersDS, IServices.IDialogService dialogService, IServices.INavigationService navigationService, IServices.ISpeechService speechService, IServices.IShareService shareService, IServices.ILiveTileService liveTileService)
        {
			_speakers_SpeakersDS = speakers_SpeakersDS;
			_dialogService = dialogService;
			_navigationService = navigationService;
			_speechService = speechService;
			_shareService = shareService;
			_liveTileService = liveTileService;
        }
		
	
		private Entities.SpeakersDSSchema _currentSpeakersDSSchema;

        /// <summary>
        /// CurrentSpeakersDSSchema property.
        /// </summary>		
        public Entities.SpeakersDSSchema CurrentSpeakersDSSchema
        {
            get
            {
				return _currentSpeakersDSSchema;
            }
            set
            {
                SetProperty(ref _currentSpeakersDSSchema, value);
            }
        }
	
		private bool _hasNextpanoramaSpeakers_Detail0;

        /// <summary>
        /// HasNextpanoramaSpeakers_Detail0 property.
        /// </summary>		
        public bool HasNextpanoramaSpeakers_Detail0
        {
            get
            {
				return _hasNextpanoramaSpeakers_Detail0;
            }
            set
            {
                SetProperty(ref _hasNextpanoramaSpeakers_Detail0, value);
            }
        }
	
		private bool _hasPreviouspanoramaSpeakers_Detail0;

        /// <summary>
        /// HasPreviouspanoramaSpeakers_Detail0 property.
        /// </summary>		
        public bool HasPreviouspanoramaSpeakers_Detail0
        {
            get
            {
				return _hasPreviouspanoramaSpeakers_Detail0;
            }
            set
            {
                SetProperty(ref _hasPreviouspanoramaSpeakers_Detail0, value);
            }
        }

        /// <summary>
        /// Delegate method for the TextToSpeechSpeakers_DetailStaticControlCommand command.
        /// </summary>
        public  void TextToSpeechSpeakers_DetailStaticControlCommandDelegate() 
        {
				_speechService.TextToSpeech(CurrentSpeakersDSSchema.Title + " " + CurrentSpeakersDSSchema.Subtitle);
        }
		

        private ICommand _textToSpeechSpeakers_DetailStaticControlCommand;

        /// <summary>
        /// Gets the TextToSpeechSpeakers_DetailStaticControlCommand command.
        /// </summary>
        public ICommand TextToSpeechSpeakers_DetailStaticControlCommand
        {
            get { return _textToSpeechSpeakers_DetailStaticControlCommand = _textToSpeechSpeakers_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(TextToSpeechSpeakers_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the ShareSpeakers_DetailStaticControlCommand command.
        /// </summary>
        public  void ShareSpeakers_DetailStaticControlCommandDelegate() 
        {
				_shareService.Share(CurrentSpeakersDSSchema.Title, CurrentSpeakersDSSchema.Subtitle, "", CurrentSpeakersDSSchema.Image);
        }
		

        private ICommand _shareSpeakers_DetailStaticControlCommand;

        /// <summary>
        /// Gets the ShareSpeakers_DetailStaticControlCommand command.
        /// </summary>
        public ICommand ShareSpeakers_DetailStaticControlCommand
        {
            get { return _shareSpeakers_DetailStaticControlCommand = _shareSpeakers_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(ShareSpeakers_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the PinToStartSpeakers_DetailStaticControlCommand command.
        /// </summary>
        public  void PinToStartSpeakers_DetailStaticControlCommandDelegate() 
        {
				_liveTileService.PinToStart(typeof(IViewModels.ISpeakers_DetailViewModel), CreateTileInfoSpeakers_DetailStaticControl());
        }
		

        private ICommand _pinToStartSpeakers_DetailStaticControlCommand;

        /// <summary>
        /// Gets the PinToStartSpeakers_DetailStaticControlCommand command.
        /// </summary>
        public ICommand PinToStartSpeakers_DetailStaticControlCommand
        {
            get { return _pinToStartSpeakers_DetailStaticControlCommand = _pinToStartSpeakers_DetailStaticControlCommand ?? new ViewModelsBase.DelegateCommand(PinToStartSpeakers_DetailStaticControlCommandDelegate); }
        }

        /// <summary>
        /// Delegate method for the NextpanoramaSpeakers_Detail0 command.
        /// </summary>
        public async void NextpanoramaSpeakers_Detail0Delegate() 
        {
				LoadingCurrentSpeakersDSSchema = true;
			var next = await  _speakers_SpeakersDS.Next(CurrentSpeakersDSSchema);

			if(next != null)
				CurrentSpeakersDSSchema = next;

			RefreshHasPrevNext();
        }
		
		
        private bool _loadingCurrentSpeakersDSSchema;
		
        public bool LoadingCurrentSpeakersDSSchema
        {
            get { return _loadingCurrentSpeakersDSSchema; }
            set { SetProperty(ref _loadingCurrentSpeakersDSSchema, value); }
        }

        private ICommand _nextpanoramaSpeakers_Detail0;

        /// <summary>
        /// Gets the NextpanoramaSpeakers_Detail0 command.
        /// </summary>
        public ICommand NextpanoramaSpeakers_Detail0
        {
            get { return _nextpanoramaSpeakers_Detail0 = _nextpanoramaSpeakers_Detail0 ?? new ViewModelsBase.DelegateCommand(NextpanoramaSpeakers_Detail0Delegate); }
        }

        /// <summary>
        /// Delegate method for the PreviouspanoramaSpeakers_Detail0 command.
        /// </summary>
        public  void PreviouspanoramaSpeakers_Detail0Delegate() 
        {
			var prev =  _speakers_SpeakersDS.Previous(CurrentSpeakersDSSchema);

			if(prev != null)
				CurrentSpeakersDSSchema = prev;

			RefreshHasPrevNext();
        }
		

        private ICommand _previouspanoramaSpeakers_Detail0;

        /// <summary>
        /// Gets the PreviouspanoramaSpeakers_Detail0 command.
        /// </summary>
        public ICommand PreviouspanoramaSpeakers_Detail0
        {
            get { return _previouspanoramaSpeakers_Detail0 = _previouspanoramaSpeakers_Detail0 ?? new ViewModelsBase.DelegateCommand(PreviouspanoramaSpeakers_Detail0Delegate); }
        }

        private async void RefreshHasPrevNext()
        {
            HasPreviouspanoramaSpeakers_Detail0 = _speakers_SpeakersDS.HasPrevious(CurrentSpeakersDSSchema);
			HasNextpanoramaSpeakers_Detail0 = await _speakers_SpeakersDS.HasNext(CurrentSpeakersDSSchema);
			LoadingCurrentSpeakersDSSchema = false;
		}
		public object NavigationContext
        {
            set
            {              
                if (!(value is Entities.SpeakersDSSchema)) { return; }
                
                CurrentSpeakersDSSchema = value as Entities.SpeakersDSSchema;
                RefreshHasPrevNext();
            }
        }
        /// <summary>
        /// Initializes a <see cref="Services.TileInfo" /> object for the Speakers_DetailStaticControl control.
        /// </summary>
		/// <returns>A <see cref="Services.TileInfo" /> object.</returns>
        public Services.TileInfo CreateTileInfoSpeakers_DetailStaticControl()
        {
            var tileInfo = new Services.TileInfo
            {
                CurrentId = CurrentSpeakersDSSchema.Title,
                Title = CurrentSpeakersDSSchema.Title,
                BackTitle = CurrentSpeakersDSSchema.Title,
                BackContent = CurrentSpeakersDSSchema.Subtitle,
                Count = 0,
                BackgroundImagePath = CurrentSpeakersDSSchema.Image,
                BackBackgroundImagePath = CurrentSpeakersDSSchema.Image,
                LogoPath = "Logo-53837e26-d89c-4b47-8990-3d7a578665e6.png"
            };
            return tileInfo;
        }
    }
}
