const AccountModel = require('../models/AccountModel')
const jwt = require('jsonwebtoken')
const KEY_LOGIN = process.env.SECRET_LOGIN || "key-login-note"

module.exports.register = async(req, res) =>{
    try{
        let {user, password, name} = req.body
        user = user.toLowerCase()
        
        var account = await AccountModel.create({
            Name: name,
            passWord: password,
            user: user
        })
        return res.status(200).json({
            message: "Create account success",
            data: account
        })
    }
    catch(e)
    {
        console.log("Error AccountController - Register\n" + e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
    
}

module.exports.login = async(req, res) =>{
  

    try{
        let {user} = req.body
        var account = await AccountModel.findOne({user: user})
        var data ={            
            user: account.user,
            name: account.Name
        }
        await jwt.sign(data, KEY_LOGIN, {expiresIn: "30d"}, (err, tokenLogin)=>{
            if(err) throw err
            return res.status(200).json({
                status: "Login success",
                message: "Login Success",
                token: tokenLogin
            })
        })
    }
    catch(e)
    {
        console.log("Error AccountController - Login\n"+ e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
}