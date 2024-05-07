const NoteModel = require('../models/NoteModel')

module.exports.GetAll = async(req, res) =>{
    
    try{
        var account = req.vars.User
        var ListNote = await NoteModel.find({AccountID: account._id})
        var List = []
        
        ListNote.map((e) =>{

            var utcDate = new Date(e.createAt);
            var localDate = utcDate.toLocaleString('vi-VN', { timeZone: 'Asia/Ho_Chi_Minh' });
            var i = {
                "ID": e.ID,
                "AccountID": e.AccountID,
                "Title":  e.Title,
                "Content": e.Content,
                "createAt": localDate,
            }
            List.push(i)
        })
           
        

        return res.status(200).json({
            message: "Get List Note Success",
            count: List.length,
            data: List
        })
    }
    catch(e)
    {
        console.log("Error NoteController - GetAll\n"+ e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
    
}

module.exports.GetByID = async(req, res) =>{
    
    try{
        var account = req.vars.User
        let {id} = req.params
        var Note = await NoteModel.findOne({ID: id, AccountID: account._id})

        if(!Note)
            return res.status(400).json({
                message: `Note '${id}' not exists`,
               
            })

        var utcDate = new Date(Note.createAt);
        var localDate = utcDate.toLocaleString('vi-VN', { timeZone: 'Asia/Ho_Chi_Minh' });
        
        return res.status(200).json({
            message: "Get Note Success",
            count: Note?.length,
            data: {
                "ID": Note.ID,
                "AccountID": Note.AccountID,
                "Title":  Note.Title,
                "Content": Note.Content,
                "createAt": localDate,
            }
        })

    }
    catch(e)
    {
        console.log("Error NoteController - GetByID\n"+ e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
    
}

module.exports.Add = async ( req, res) =>{
    try{
        let {title, content} = req.body

        var ListNote = await NoteModel.find()

        var ID = ListNote?.length + 1

        let AccountID = req.vars.User._id
        let Note = await NoteModel.create({
            ID,
            AccountID,
            Title: title,
            Content: content           
        })

        var utcDate = new Date(Note.createAt);
        var localDate = utcDate.toLocaleString('vi-VN', { timeZone: 'Asia/Ho_Chi_Minh' });
        
        return res.status(200).json({
            message: "Get List Note Success",           
            data: {
                "ID": Note.ID,
                "AccountID": Note.AccountID,
                "Title":  Note.Title,
                "Content": Note.Content,
                "createAt": localDate,
            }
        })

    }
    catch(e)
    {
        console.log("Error NoteController - Add\n"+ e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
   
}

module.exports.Delete = async ( req, res) =>{
    try{
        let {id} = req.params
        let Note = await NoteModel.findOneAndDelete({ID: id})

        return res.status(200).json({
            message: `Delete Note '${id}' Success`,           
            data: Note
        })

    }
    catch(e)
    {
        console.log("Error NoteController - Add\n"+ e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
   
}

module.exports.Edit = async ( req, res) =>{
    try{
        let {id} = req.params
        let {title, content} = req.body
        var note = await NoteModel.findOne({ID: id})
        let Note = await NoteModel.findByIdAndUpdate({_id: note._id}, {
            Title: title,
            Content: content
        }, {new: true})

        return res.status(200).json({
            message: `Delete Note '${id}' Success`,           
            data: Note
        })

    }
    catch(e)
    {
        console.log("Error NoteController - Edit\n"+ e);
        return res.status(500).json({
            message: "Server error. Try again"
        })
    }
   
}