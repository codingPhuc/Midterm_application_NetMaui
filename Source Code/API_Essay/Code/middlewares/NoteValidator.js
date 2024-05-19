const NoteModel = require('../models/NoteModel')

module.exports.Add = (req, res, next) =>
{
    let {title, content} = req.body
    var mess = ""
    if(!title)
        mess= "Please input title"
    else if(!content)
        mess= "Please input content"

    if(mess)
        {
            return res.status(400).json({
                message: mess
            })   
        }

    return next()
}

module.exports.Delete = async (req, res, next) =>
{
    let {id} = req.params
    var account = req.vars.User
    var Note = await NoteModel.findOne({ID: id, AccountID: account._id})

    
    if(!Note)
        {
            return res.status(400).json({
                message: `Note ${id} not exists`
            })   
        }

    return next()
}

module.exports.Edit = async (req, res, next) =>
{
    let {id} = req.params

    let {title, content} = req.body
    var account = req.vars.User

    var Note = await NoteModel.findOne({ID: id, AccountID: account._id})

    
    if(!Note)
        {
            return res.status(400).json({
                message: `Note ${id} not exists`
            })   
        }
        
    if(!title && !content)
        {
            return res.status(400).json({
                message: `Please provide title or content`
            })   
        }
    return next()
}