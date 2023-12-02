const connection = require('../DB')
const peliculasController = {}

var query

peliculasController.getPeliculas = (req, res)=>{
    query = "SELECT * from Peliculas"
    connection.query(query, function (err, result) {
        if (err) console.log(err)
        res.json(result.recordsets[0])
    })
}

peliculasController.getTopPeliculas = (req, res)=>{
    query = "SELECT TOP 5 * FROM Peliculas WHERE Puntos > 0 ORDER BY Puntos DESC"
    connection.query(query, function (err, result) {
        if (err) console.log(err)
        res.json(result.recordsets[0])
    })
}

peliculasController.getPuntos = (req, res)=>{
    query = "SELECT * from Peliculas where PeliculaID = " + req.params.PeliculaID
    connection.query(query, function (err, result) {
        if (err) console.log(err)
        res.json(result.recordsets[0][0])
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
            res.json(result.recordsets[0])
        })
    })
}

module.exports = peliculasController