using System;
using CodeDrivers.Models.Car;
using CodeDrivers.Repository;


//Powitanie użytkownika. 
//Użytkownik programu dokonuje wyboru : admin/user
//Użytkownik opcjonalnie może zakończyć program: X
//Po przejściu admin/user proponuję dodatkowe menu z opcjami: 
//dla admina (wprowadzenie auta, usunięcie auta z listy, edycja pozycji)
//dla usera (Wyszukanie auta, zmiana terminu rezerwacji, odwołanie rezerwacji)

namespace CodeDrivers
{
	internal class Menu_tekstowe
	{
		CarRepository carListRepository = new CarRepository();
		Car car = new Car(CarBrand.BMW,"A1");
		public string Rang { get; set; }
		public Menu_tekstowe(string rang)
		{
			carListRepository.FillRepository();
			Rang = rang;

			switch (rang)
			{
				case "admin":
					AdminPanel();
					break;
				case "user":
					UserPanel();
					break;
			}
		}
		#region AdminPanel
		void AdminPanel() //Panel admina
		{
			Console.WriteLine("Tutaj pojawia sie panel admina");
			try
			{
				Console.WriteLine("1: Wprowadz auta");
				Console.WriteLine("2: Usun auta z listy");
				Console.WriteLine("3: Edycja pozycji");
				Console.WriteLine("4: Zmien range");
				Console.WriteLine();
				int userIntPanel = int.Parse(Console.ReadLine());
				if (userIntPanel > 4 || userIntPanel < 0)
				{
					Console.Clear();
					Console.WriteLine("Liczba nie poprawna, wprowadź ponownie");
					AdminPanel();
				}

				switch (userIntPanel)
				{
					case 1:
						Console.WriteLine("Dodaj auta");
						AddCar();
						AdminPanel();
						break;
					case 2:
						Console.WriteLine("Usun auta z listy");
						RemoveCar();
						AdminPanel();
						break;
					case 3:
						Console.WriteLine("Edycja pozycji");
						EditPosition();
						AdminPanel();
						break;
					case 4:
						Console.WriteLine("Zmien range (testowe)");

						UserPanel();
						break;
				}
			}
			catch
			{
				Console.WriteLine("Erorr :(");
				AdminPanel();
			}
		}
		#endregion

		#region UserPanel()
		void UserPanel() //Panel uzytkownika
		{
			try
			{
				Console.WriteLine("1: wyświetl auto");
				Console.WriteLine("2: Zmień termin rezerwacji");
				Console.WriteLine("3: Odwolanie rezerwacji");
				Console.WriteLine("4: Zarezerwuj pojazd");
				Console.WriteLine("5: Zmien range");
				Console.WriteLine();
				int userIntPanel = int.Parse(Console.ReadLine());
				if (userIntPanel > 4 || userIntPanel < 0)
				{
					Console.Clear();
					Console.WriteLine("Liczba nie poprawna, wprowadź ponownie");
					UserPanel();
				}

				switch (userIntPanel)
				{
					case 1:
						Console.WriteLine("Wyswietl auto");
						carListRepository.DisplayAllItems(carListRepository.GetAllAvailable());
						Console.WriteLine("");
						UserPanel();
						break;
					case 2:
						Console.WriteLine("Zmiana terminu rezerwacji");
						UserPanel();
						break;
					case 3:
						Console.WriteLine("Odwolanie rezerwacji");
						UserPanel();
						break;
					case 4:
						DateTime? reservationStartDate = null;
						DateTime? reservationEndDate = null;

						do
						{
							reservationStartDate = DataHandler.GetDate("Podaj date i godzine poczatku rezerwacji");
							reservationEndDate = DataHandler.GetDate("Podaj date konca rezerwacji");

							if (reservationStartDate >= reservationEndDate)
							{
								Console.WriteLine("Data konca rezerwacji musi byc wieksza niz data poczatku rezerwacji!!");
							}
						} while (reservationEndDate <= reservationStartDate);

                            UserPanel();
						break; 
					case 5:
						Console.WriteLine("Zmien range (testowe)");
						AdminPanel();
						break;
				}
			}
			catch
			{
				Console.WriteLine("Erorrek :(");
				UserPanel();
			}
		}
		#endregion

		#region AddCar
		void AddCar()
		{
			try
			{
                CarEditInformation(0,0);
			} catch
			{
				AdminPanel();
			}
		}
		#endregion

		#region RemoveCar
		void RemoveCar()
		{
			try
			{
				carListRepository.DisplayAllItems(carListRepository.GetAll());
				Console.WriteLine("Wprowadz Id samochodu jaki chcesz usunac z listy:");
				int id = int.Parse(Console.ReadLine());
				carListRepository.RemoveCar(id);
				AdminPanel();
			}
			catch
			{
				AdminPanel();
			}

        }
        #endregion

        #region EditPosition
        void EditPosition()
		{
			bool canEdit = false;
			carListRepository.DisplayAllItems(carListRepository.GetAll());
            Console.WriteLine("Wpisz ID aby zmienic pozycje");
			int id = int.Parse(Console.ReadLine());
			for (int i = 0; i < carListRepository.GetAll().Count; i++)
			{
				if(id == carListRepository.GetAll()[i].Id)
				{
					canEdit = true; 
					break;
				}
			}
			if (canEdit)
			{
				CarEditInformation(1,id);
			}
        }
		#endregion

        #region CarEditInformation
		void CarEditInformation(int i, int id)
		{
            Console.WriteLine("Wszystkie dostępne marki:");
            foreach (var BrandCar in Enum.GetValues(typeof(CarBrand)))
            {
                Console.WriteLine(BrandCar);
            }
            Console.WriteLine();
            Console.WriteLine("Wprowadz marke:");
            string carBrandString = Console.ReadLine(); //Zamienia wszystkie litery na małe
            carBrandString.ToLower();

            string carBrandLetterCapitalized;
            if (string.Equals(carBrandString, "BMW", StringComparison.OrdinalIgnoreCase) || string.Equals(carBrandString, "VW", StringComparison.OrdinalIgnoreCase))
            {
                carBrandLetterCapitalized = carBrandString.ToUpper();
                carBrandString = carBrandLetterCapitalized;
            }
            else
            {
                carBrandLetterCapitalized = char.ToUpper(carBrandString[0]) + carBrandString.Substring(1); //Zamienia 1 litere na wielka
                carBrandString = carBrandLetterCapitalized;
            }
            CarBrand carBrand = (CarBrand)Enum.Parse(typeof(CarBrand), carBrandString);
            Console.WriteLine();
            car.Brand = carBrand;
            Console.WriteLine("Wprowadz model:");
            foreach (var modelList in car.Models)
            {
                Console.WriteLine(modelList);
            }
            Console.WriteLine();
            string carModel = Console.ReadLine().ToLower();
            string carModelLetterCapitalized;
            if (string.Equals(carModel, "RAV4", StringComparison.OrdinalIgnoreCase)) //Wyjatek
            {
                carModelLetterCapitalized = carModel.ToUpper();
                carModel = carModelLetterCapitalized;
            }
            else if (string.Equals(carModel, "up!", StringComparison.OrdinalIgnoreCase)) //Wyjatek
            {
                carModelLetterCapitalized = carModel.ToLower();
                carModel = carModelLetterCapitalized;
            }
            else
            {
                carModelLetterCapitalized = char.ToUpper(carModel[0]) + carModel.Substring(1);
                carModel = carModelLetterCapitalized;
            }
            car.Model = carModel;
            Console.WriteLine();
            Console.WriteLine("Wprowadż rodzaj:");
            foreach (var segment in Enum.GetValues(typeof(CarSegment)))
            {
                Console.WriteLine(segment);
            }
            string carSegmentString = Console.ReadLine().ToLower();
            string carSegmentLetterCapitalized;
            if (string.Equals(carSegmentString, "SUV", StringComparison.OrdinalIgnoreCase))
            {
                carSegmentLetterCapitalized = carSegmentString.ToUpper();
                carSegmentString = carSegmentLetterCapitalized;
            }
            else
            {
                carSegmentLetterCapitalized = char.ToUpper(carSegmentString[0]) + carSegmentString.Substring(1);
                carSegmentString = carSegmentLetterCapitalized;
            }
            CarSegment carSegment = (CarSegment)Enum.Parse(typeof(CarSegment), carSegmentString);
            Console.WriteLine();
            car.Segment = carSegment;
            Console.WriteLine("Wprowadz rodzaj napędu:");
            foreach (var gearType in Enum.GetValues(typeof(GearType)))
            {
                Console.WriteLine(gearType);
            }
            string gearTypeString = Console.ReadLine().ToLower();
            string gearTypeLetterCapitalized;
            gearTypeLetterCapitalized = char.ToUpper(gearTypeString[0]) + gearTypeString.Substring(1);
            gearTypeString = gearTypeLetterCapitalized;

            GearType gearTrasmission = (GearType)Enum.Parse(typeof(GearType), gearTypeString);
            car.GearTransmission = gearTrasmission;
            Console.WriteLine();
            Console.WriteLine("Podaj cene wypozyczenia za dzien:");
            decimal pricePerDay = decimal.Parse(Console.ReadLine());
			if(i == 0) //Add
			{
                carListRepository.AddCar(carBrand, carModel, carSegment, gearTrasmission, pricePerDay);
            }else if (i == 1) //Edit
			{
				carListRepository.GetAll()[id].Brand = carBrand;
				carListRepository.GetAll()[id].Model = carModel;
				carListRepository.GetAll()[id].Segment = carSegment;
				carListRepository.GetAll()[id].GearTransmission = gearTrasmission;
				carListRepository.GetAll()[id].PricePerDay = pricePerDay;
			}
        }
        #endregion
	}
}

