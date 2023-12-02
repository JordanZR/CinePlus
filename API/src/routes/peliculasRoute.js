var app = require('../index')

const peliculasController = require('../controllers/peliculasController')

app.get('/peliculas', peliculasController.getPeliculas)
app.get('/peliculas/puntos/:PeliculaID', peliculasController.getPuntos)
app.get('/peliculas/update/:PeliculaID/:puntos', peliculasController.updatePuntuacion)
