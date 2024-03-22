using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWindFormsMVP.Models;
using CRUDWindFormsMVP.Views;


namespace CRUDWindFormsMVP.Presenters
{
    internal class PetPresenter
    {
        //Fields
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petsList;

        //Constructor
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petsBindingSource=new BindingSource();
            this.view = view;
            this.repository = repository;

            //Suscribe event handlre methods to view events

            this.view.SearchEvent += Searchpet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectPetToEdit;
            this.view.DeleteEvent += DeleteSelectPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;

            //Set pets binding source
            this.view.SetPetListBindingSource(petsBindingSource);

            //Load pet List view
            LoadAllPetList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllPetList()
        {
            petsList = repository.GetAll();
            petsBindingSource.DataSource = petsList; //set data source
        }

        private void Searchpet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                 petsList = repository.GetByValue(this.view.SearchValue);
            else petsList =repository.GetAll();
            petsBindingSource.DataSource= petsList;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void SavePet(object sender, EventArgs e)
        {
            var model= new PetModel();
            model.Id = Convert.ToInt32(view.PetId);
            model.Name = view.PetName;
            model.Type = view.PetType;
            model.Colour = view.PetColour;
            try
            {
              new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit) //Edit model
                {
                    repository.Edit(model);
                    view.Message = "Pet edited successfuly"; 
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Pet added successfully";
                }
                view.IsSuccessful= true;
                LoadAllPetList();
                CleanviewFields();


            }
            catch (Exception ex)
            {

                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.PetId = "0";
            view.PetName = "";
            view.PetType = "";
            view.PetColour = "";
            
        }

        private void DeleteSelectPet(object sender, EventArgs e)
        {
            try
            {
                var pet = (PetModel)petsBindingSource.Current;
                repository.Delete(pet.Id);
                view.Message = "Pet delated successfully";
                LoadAllPetList();
            }
            catch(Exception ex) 
            {
                view.IsSuccessful = false;
                view.Message = "An error, could not delete pet";
            }
        }

        private void LoadSelectPetToEdit(object sender, EventArgs e)
        {
            var pet = (PetModel)petsBindingSource.Current;
            view.PetId = pet.Id.ToString();
            view.PetName = pet.Name;
            view.PetType = pet.Type;
            view.PetColour=pet.Colour;
            view.IsEdit = true;
        }

        private void AddNewPet(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }


    }
}
