const express = require('express')
const _APP = express.Router()

//Middleware
const AccountValidator = require('../middlewares/Validator')

//Controller
const AccountControler = require('../controllers/AccountController')

_APP.post('/',AccountValidator.register , AccountControler.register)
_APP.post('/login', AccountValidator.login , AccountControler.login)




module.exports = _APP