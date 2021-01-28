using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Repository;
using Xamarin.Template.ViewModels;

namespace Xamarin.Template.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpViewSpace : PopupPage
    {
        SpaceRepository spaceRepository;
        public PopUpViewSpace(object _BindingContext)
        {
            spaceRepository = new SpaceRepository();
            InitializeComponent();
            BindingContext = _BindingContext;

            if (String.IsNullOrEmpty(((EspaceViewModel)this.BindingContext).Name) 
                || String.IsNullOrEmpty(((EspaceViewModel)this.BindingContext).Picture)
                || String.IsNullOrEmpty(((EspaceViewModel)this.BindingContext).Description)                
                )
            {
                txtInfo.Text = "Un ou plusieurs champs vide !";
            }
            else
            {
                if(!((EspaceViewModel)this.BindingContext).Capacity.ToString().All(char.IsDigit) || ((EspaceViewModel)this.BindingContext).Capacity == 0)
                {
                    txtInfo.Text = "La capacity doit être suppérieur à 0";
                }
                else
                {
                    txtInfo.Text = string.Empty;
                    BtnValider.IsEnabled = true;
                }
            
            }
           
        }

        private async void BtnValider_Clicked(object sender, System.EventArgs e)
        {
            Space s = new Space
            {
                Capacity = ((EspaceViewModel)this.BindingContext).Capacity,
                CreatedAt = DateTime.Now,
                Description = ((EspaceViewModel)this.BindingContext).Description,
                Name = ((EspaceViewModel)this.BindingContext).Name,
                Picture = ((EspaceViewModel)this.BindingContext).Picture,
                Type = ((EspaceViewModel)this.BindingContext).Type,
                CreatedBy = 2

            };

            await spaceRepository.CreateSpace(s);

            await DisplayAlert("Création de l'espace", "L'espace a bien été créé", "Ok");

            await PopupNavigation.Instance.PopAsync();

           
        }
    }
}