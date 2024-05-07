const mongoose = require('mongoose')
const moment = require('moment-timezone');
const dateVietnam = moment.tz(Date.now(), "Asia/Ho_Chi_Minh");

let NoteSchema = new mongoose.Schema({
    ID: {
        type: Number,
        unique: true 
    },
    AccountID: String,
    Title: String,
    Content: String,
    createAt:{
        type: Date,
        default: dateVietnam
    }

})

module.exports = mongoose.model('note', NoteSchema)