const jwt = require('jsonwebtoken')
const SECRET_LOGIN = process.env.SECRET_LOGIN || 'key-login-note'
const AccountModel = require('../models/AccountModel')


module.exports.AuthAccount = (req, res, next) =>{
    try{
        // Get token from header or body
        let tokenFromHeader =  req.header('Authorization')
    
        let token = undefined
    
        if(!tokenFromHeader)
            token =  req.body.token  
    
        else
            token = tokenFromHeader.split(' ')[1]
    
    
        if(!token || token === undefined)
        {
            return res.status(400).json({
                status: "Authorization",           
                message: 'Please login or have token login'
            })
        }

        // verify token
    
        jwt.verify(token, SECRET_LOGIN, async(err, data)=>{
            if(err)
            {
                return res.status(400).json({
                   status: 'Invalid Token',
                    message: 'Login failed or expires'
                })
            }
    
            let user = data.user?.toLowerCase()
            
            
            var account = await AccountModel.findOne({              
                    user: user,               
            })      
            
            if(!account)
            {
                return res.status(401).json({
                    status: 'Account not exists',
                    message: 'Account not exists or just removed'
                })
            }
    
            req.vars.User = account
    
            return next()
        })
    }
    catch(err)
    {
        console.log("Error at Auth - AuthAccount: ", err);
        
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
   

  
}