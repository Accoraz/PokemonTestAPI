// Form1.cs
// Pokemon Species Lookup Application
// Uses the PokeAPI.NET wrapper to retrieve and display
// species information based on user input.
// Results are displayed in a ListBox for clean presentation.
using System;
using System.Windows.Forms;
using PokeAPI;

namespace PokemonTestAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Search button click.
        /// Validates input then fetches and displays Pokemon species data.
        /// </summary>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            ClearResults();

            string userInput = txtSpecies.Text.Trim().ToLower();

            // Validate input is not empty
            if (string.IsNullOrEmpty(userInput))
            {
                lblError.Text = "Please enter a Pokemon name or ID.";
                return;
            }

            btnSearch.Enabled = false;
            lblError.Text = "Searching...";

            try
            {
                PokemonSpecies species;

                // Determine if the user entered a numeric ID or a name
                if (int.TryParse(userInput, out int pokemonId))
                {
                    if (pokemonId <= 0)
                    {
                        lblError.Text = "ID must be a positive number.";
                        return;
                    }

                    species = await DataFetcher.GetApiObject<PokemonSpecies>(pokemonId);
                }
                else
                {
                    // Validate name only contains letters and hyphens (e.g. mr-mime)
                    foreach (char c in userInput)
                    {
                        if (!char.IsLetter(c) && c != '-')
                        {
                            lblError.Text = "Please enter a valid Pokemon name or ID.";
                            btnSearch.Enabled = true;
                            return;
                        }
                    }

                    species = await DataFetcher.GetNamedApiObject<PokemonSpecies>(userInput);
                }

                DisplayResults(species);
            }
            catch (Exception)
            {
                lblError.Text = "Pokemon not found. Please check the name or ID and try again.";
                lstResults.Visible = false;
            }
            finally
            {
                btnSearch.Enabled = true;
            }
        }

        /// <summary>
        /// Populates the ListBox with all required species attributes.
        /// Each item is a formatted string describing one attribute.
        /// </summary>
        /// <param name="species">The PokemonSpecies object returned from the API.</param>
        private void DisplayResults(PokemonSpecies species)
        {
            lstResults.Items.Clear();

            // Name
            lstResults.Items.Add("Name: " + CapitalizeFirst(species.Name));

            // Base happiness
            lstResults.Items.Add("Base Happiness: " + species.BaseHappiness);

            // Capture rate
            lstResults.Items.Add("Capture Rate: " + species.CaptureRate);

            // Habitat — can be null for legendaries and mythicals
            if (species.Habitat != null)
                lstResults.Items.Add("Habitat: " + CapitalizeFirst(species.Habitat.Name));
            else
                lstResults.Items.Add("Habitat: Unknown");

            // Growth rate
            if (species.GrowthRate != null)
                lstResults.Items.Add("Growth Rate: " + CapitalizeFirst(species.GrowthRate.Name));
            else
                lstResults.Items.Add("Growth Rate: Unknown");

            // First English flavor text entry
            string flavorText = "Flavor Text: Not available";
            if (species.FlavorTexts != null)
            {
                foreach (PokemonSpeciesFlavorText entry in species.FlavorTexts)
                {
                    if (entry.Language.Name == "en")
                    {
                        // Clean up newline characters the API includes in flavor text
                        string cleanedText = entry.FlavorText
                            .Replace("\n", " ")
                            .Replace("\f", " ");
                        flavorText = "Flavor Text: " + cleanedText;
                        break;
                    }
                }
            }
            lstResults.Items.Add(flavorText);

            // First egg group
            if (species.EggGroups != null && species.EggGroups.Length > 0)
                lstResults.Items.Add("Egg Group: " + CapitalizeFirst(species.EggGroups[0].Name));
            else
                lstResults.Items.Add("Egg Group: None");

            lstResults.Visible = true;
            lblError.Text = "";
        }

        /// <summary>
        /// Clears all ListBox items it is now ready for a new search.
        /// </summary>
        private void ClearResults()
        {
            lstResults.Items.Clear();
            lstResults.Visible = false;
            lblError.Text = "";
        }

        /// <summary>
        /// Capitalizes the first letter of a string for clean display.
        /// API names return in lowercase (e.g. "pikachu" becomes "Pikachu").
        /// </summary>
        /// <param name="input">The string to capitalize.</param>
        /// <returns>The string with its first letter capitalized.</returns>
        private string CapitalizeFirst(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        /// <summary>
        /// Clears the error label as the user begins typing a new search.
        /// </summary>
        private void txtSpecies_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}