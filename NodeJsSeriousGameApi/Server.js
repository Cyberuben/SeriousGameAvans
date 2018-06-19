const express = require('express');
const MongoClient = require('mongodb').MongoClient;
const bodyParser = require('body-parser');
const app = express();

const port = 8000;
const mongodbUrl = 'mongodb://test:test1234@ds263380.mlab.com:63380/seriousgame';
let db;
app.use(bodyParser())

const database = module.exports = {
    url : mongodbUrl
  };

MongoClient.connect(database.url, (err, database) => {
    app.listen(port, () => {
        if (err != null){
            console.log(err);
        }
        db = database.db('seriousgame');
        console.log('We are live on ' + port);
        console.log(db);
    });
});

app.get('/api/users/:amountofusers', (req, res) => {
    var amountofusers = req.params.amountofusers;
    console.log(amountofusers);
    
   db.collection('seriousgame').find().sort({HighScore: -1  }).limit(parseInt(amountofusers)).toArray(function(error, documents) {
        res.send(documents);
   });
}); 

app.post('/api/users', (req, res) => {
    const user = { UserName: req.body.UserName, Department: req.body.Department, HighScore: req.body.HighScore}
    console.log(req.body);
    db.collection('seriousgame').insert(user, (err, results) => {
        if (err) { 
            res.send({ 'error': 'An error has occurred' }); 
          } else {
            res.send(user);
          }
    })
});

