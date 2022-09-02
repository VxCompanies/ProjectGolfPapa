using ProjectGolfPapa.Models;
using ProjectGolfPapa.ViewModels.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGolfPapa.ViewModels
{
    public class RegisterPetViewModel : ViewModelBase
    {
		private Pet _pet;
		public Pet Pet
		{
			get => _pet;
			set
			{
				_pet = value;
				OnPropertyChanged(nameof(Pet));
			}
		}

		private bool _isError;
		public bool IsError
		{
			get => _isError;
			set
			{
				_isError = value;
				OnPropertyChanged(nameof(IsError));
			}
		}

		public RegisterPetCommand RegisterPetCommand { get; set; }

		public RegisterPetViewModel()
		{
			_pet = new();
			_isError = false;

			RegisterPetCommand = new();
        }
	}
}
