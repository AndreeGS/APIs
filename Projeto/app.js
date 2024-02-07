/*Imports*/

require("dotenv").config()
const express = require('express')
const mongoose = require ('mongoose')
const bcrypt = require('bcrypt')
const jwt = require('jsonwebtoken')

const app = express()

//Open Route - Public Route
app.get('/', (req, res) =>{
    res.status(200).json({msg: "Bem vindo a nossa API!"})
})

app.listen(3000)