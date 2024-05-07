const mongoose = require('mongoose')

let AccountSchema = new mongoose.Schema({
    Name: String,
    user: String,
    passWord: String   

})

module.exports = mongoose.model('account', AccountSchema)