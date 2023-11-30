const connection = require('../DB')
const peliculasController = {}

var query

peliculasController.getPeliculas = (req, res)=>{
    query = "SELECT * from Peliculas"
    connection.query(query, function (err, result) {
        if (err) console.log(err)
        res.json(result)
    })
}

peliculasController.getPuntos = (req, res)=>{
    query = "SELECT puntos from Peliculas where PeliculaID = " + req.params.PeliculaID
    connection.query(query, function (err, result) {
        if (err) console.log(err)
        res.json(result)
    })
}

peliculasController.updatePuntuacion = (req,res)=>{
    
    query = "UPDATE Peliculas SET puntos = " + req.params.puntos + " WHERE PeliculaID = " + req.params.PeliculaID

    console.log(query)
    connection.query(query, function (err, result) {
        if (err) console.log(err)
        query = "SELECT * from Peliculas"
        connection.query(query, function (err, result) {
            if (err) throw err;
            res.json(result)
        })
    })
}

module.exports = peliculasController