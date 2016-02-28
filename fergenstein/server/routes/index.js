var express = require('express');
var router = express.Router();
var fs = require('fs');

var multer  =   require('multer');


router.get('/getobj', function(req, res, next) {
	fs.readFile('teapot.obj', 'utf8', function (err,data) {
	  if (err) {
	    return console.log(err);
	  }
	  res.write(data);
	  res.end();
	});
});


//file upload stuff
var storage =   multer.diskStorage({
  destination: function (req, file, callback) {
    callback(null, './');
  },
  filename: function (req, file, callback) {
    callback(null, "doot.obj");
  }
});

var upload = multer({ storage : storage}).single('userPhoto');

router.post('/upl',function(req,res){
    upload(req,res,function(err) {
        if(err) {
          console.log(err);
          return res.end("Error uploading file.");
        }
        res.redirect("success.html");
    });
});


module.exports = router;
             