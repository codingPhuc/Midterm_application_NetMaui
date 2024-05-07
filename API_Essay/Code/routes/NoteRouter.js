const express = require('express')
const _APP = express.Router()

// middleware
const Auth = require('../middlewares/Auth')
const Validator = require('../middlewares/NoteValidator')

//controller
const NoteController = require('../controllers/NoteController')


_APP.get("/", Auth.AuthAccount, NoteController.GetAll)
_APP.get("/:id", Auth.AuthAccount, NoteController.GetByID)

_APP.post("/", Auth.AuthAccount, Validator.Add, NoteController.Add)

_APP.delete("/:id", Auth.AuthAccount, Validator.Delete, NoteController.Delete)

_APP.patch("/:id", Auth.AuthAccount, Validator.Edit, NoteController.Edit)

module.exports = _APP