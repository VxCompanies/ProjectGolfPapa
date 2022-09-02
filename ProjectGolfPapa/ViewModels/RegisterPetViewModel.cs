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

		private decimal _x;
		public decimal X
		{
			get => _x;
			set
			{
				_x = value;
				OnPropertyChanged(nameof(X));
			}
		}

		private decimal _y;
		public decimal Y
		{
			get => _y;
			set
			{
				_y = value;
				OnPropertyChanged(nameof(Y));
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

		private bool _isMale;
		public bool IsMale
		{
			get => _isMale;
			set
			{
				_isMale = value;
				OnPropertyChanged(nameof(IsMale));
			}
		}

		public RegisterPetAsyncCommand RegisterPetAsyncCommand { get; set; }

		public RegisterPetViewModel()
		{
			Pet = new()
			{
				BirthDate = DateTime.Now,
				Owner = new(),
				Location = new()
			};

			IsMale = true;

            RegisterPetAsyncCommand = new();
        }
	}
}
