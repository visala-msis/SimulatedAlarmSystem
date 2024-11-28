using SimulatedAlarmSystem.BL.Interfaces;
using SimulatedAlarmSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;
using System.Xml;


namespace SimulatedAlarmSystem.BL.Services
{
    public class UserService : IUserService
    {

        private IEnumerable<User> users;
        string filePath = "Config/UserData.xml";

        /// <summary>
        /// Method to get user list from XML
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> LoadUsers()
        {
            
            var xdoc = XDocument.Load(filePath);
            foreach (var elem in xdoc.Descendants("User"))
            {
                yield return new User
                {
                    UserName = (string)elem.Element("Username"),
                    Password = (string)elem.Element("Password"),
                    Email = (string)elem.Element("Email"),
                };
            }
        }

        /// <summary>
        /// Method to register user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public RegistrationResuslt RegisterUser(User user)
        {
            users = LoadUsers();
            // Check if the username already exists in the database
            var existingUser = users.FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);

            if (existingUser != null)
            {
                return new RegistrationResuslt { IsSuccess = false, ErrorMessage = "Username or email already taken." };
            }

            // Hash password before saving to DB
            //var hashedPassword = _passwordHasher.HashPassword(user, user.Password);
           // user.Password = hashedPassword;

            // Add user to the database

            SaveUser( user);

            return new RegistrationResuslt { IsSuccess = true };
        }

        /// <summary>
        /// Method to save user data into local database
        /// </summary>
        /// <param name="user"></param>
        public void SaveUser(User user)
        {

            // Load the existing XML file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);  // Load the XML file into the XmlDocument

            // Create a new <User> element for the new user
            XmlElement newUserElement = xmlDoc.CreateElement("User");

            // Create <Username>, <Password>, and <Email> elements
            XmlElement usernameElement = xmlDoc.CreateElement("Username");
            usernameElement.InnerText = user.UserName;
            newUserElement.AppendChild(usernameElement);

            XmlElement passwordElement = xmlDoc.CreateElement("Password");
            passwordElement.InnerText = user.Password;
            newUserElement.AppendChild(passwordElement);

            XmlElement emailElement = xmlDoc.CreateElement("Email");
            emailElement.InnerText = user.Email;
            newUserElement.AppendChild(emailElement);

            // Append the new user to the root element (<Users>)
            XmlNode root = xmlDoc.SelectSingleNode("/Users");
            root.AppendChild(newUserElement);

            // Save the updated XML back to the file
            xmlDoc.Save(filePath);
        }



        /// <summary>
        /// This Mmethod is created to check if user exists in local data base i.e, XML
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool LoginUser(User user)
        {
            try
            {
                users = LoadUsers();
                // Check if the username already exists in the database
                var existingUser = users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (existingUser != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //Logger can be added to track usage
                return false;
            }
        }
    }
}
        
    
