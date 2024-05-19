// Import library
const express = require('express')
const cors = require('cors')
require('dotenv').config()

//
const AccountRouter = require('./routes/AccountRouter')
const NoteRouter = require('./routes/NoteRouter')
// Define variable 
const _APP = express()
const _PORT = process.env.PORT || 3000

// Config 
_APP.use(express.json())
_APP.use(express.urlencoded({extended: true}))

_APP.use(cors())

_APP.use((req, res, next)=>{
    req.vars = {root: __dirname}
    next()
 })

 


_APP.use('/api/account', AccountRouter)
_APP.use('/api/note', NoteRouter)

_APP.use('*', (req, res)=>{
    res.status(404).json({
        status: "Not Found",
        message: "The url not support"
    })
})
// Define Function
 
const startProgram = async()=>{
    // console.log(await bcrypt.hash("12345", 10));
    
    
     await require('./models/DB')
     .then(async()=>{

         console.log("Connect DB Success");   

        _APP.listen(_PORT, () => {
            console.log("App listen at: http://localhost:" + _PORT);
        })
    
     })    
     .catch((err)=>{
         console.log("Connect DB Failed: ", err);
     })
   
 }
 
 // Run Function 
 startProgram()


