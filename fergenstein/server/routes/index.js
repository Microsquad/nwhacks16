var express = require('express');
var router = express.Router();
var fs = require('fs');

/* GET home page. */
router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

router.get('/getobj', function(req, res, next) {
  

	fs.readFile('teapot.obj', 'utf8', function (err,data) {
	  if (err) {
	    return console.log(err);
	  }
	  res.write(data);
	  res.end();
	});
});

module.exports = router;
             