
using WhatFlix.Domain.Model;

namespace WhatFlix.Domain.Validators
{
    public class UserValidator
    {
        public UserValidator()
        {
            
        }
        public bool Validate(User user){
            //if(usr)
            return user.Name != "";
        }
    }
}