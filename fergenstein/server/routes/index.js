var express = require('express');
var router = express.Router();
var fs = require('fs');

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/objs');

var Obj = mongoose.model('obj', { name: String });



var multer  =   require('multer');


router.get('/getobj', function(req, res, next) {
  var selectedFile = router.selectedobj;
  if(!selectedFile){
    console.log("no selected obj; defaulting to teapot");
    selectedFile = "teapot.obj";
  }
  console.log("attempting to get " + selectedFile);
	fs.readFile('public/' + selectedFile, 'utf8', function (err,data) {
	  if (err) {
	    return console.log(err);
	  }
	  res.write(data);
	  res.end();
	});
});

router.get('/getobjs', function(req, res, next) {
	Obj.find({}, function(err, objs){
        if(err){
            console.log(err);
            res.end("err");
        }
        res.send(objs);
    }); 
});


//file upload stuff
var storage =   multer.diskStorage({
  destination: function (req, file, callback) {
    callback(null, './');
  },
  filename: function (req, file, callback) {
    var newobj = new Obj({ name: file.originalname });
    newobj.save(function (err) {
          if (err){
            console.log('err saving to db');
          }
          console.log('saved to db');
            callback(null, "public/" + file.originalname);
    });
      
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

router.post('/selectobj',function(req,res){
  console.log("selected: " + req.body.name);
  router.selectedobj = req.body.name;
  res.end("success");
});

module.exports = router;
             