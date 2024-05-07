const AccountModel = require('../models/AccountModel')

module.exports.register = async(req, res, next) =>{
    let {user, password, name} = req.body
    let mess = ""
    if(!user)
        mess ="Please input user"
    else if(!password)
        mess ="Please input password"
    else if(!name)
        mess ="Please input name"
    if(mess)
    {
        return res.status(400).json({
            message: mess
        })   
    }
    
    let account = await AccountModel.findOne({user: user})
    if(account)
        return res.status(400).json({
            message: "Account have been exists"
        })   

    return next()
        
}
module.exports.login = async(req, res, next) =>{
    let {user, password} = req.body
    let mess = ""
    if(!user)
        mess ="Please input user"
    else if(!password)
        mess ="Please input password"

    if(mess)
    {
        return res.status(400).json({
            message: mess
        })   
    }
    let account = await AccountModel.findOne({user: user.toLowerCase()})
    if(!account)
        return res.status(400).json({
            message: "Account not exists"
        })

    if(password !== account.passWord)
        return res.status(400).json({
            message: "Password not Correct"
        })

    return next()
}