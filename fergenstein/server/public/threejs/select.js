//var container = document.getElementById( "object-container" );

//renderer.domElement = container;
var renderer = new THREE.WebGLRenderer();
renderer.setClearColor(0x000000); // black background colour
document.getElementById("object-container").appendChild(renderer.domElement);
//document.body.appendChild(renderer.domElement);

var scene;
var camera;

createScene('girl.obj');

function createScene(fileLoc) {
  scene = new THREE.Scene();

  // var worldFrame = new THREE.AxisHelper(5) ;
  // scene.add(worldFrame);

  camera = new THREE.PerspectiveCamera( 60, 1, 1, 10);
  camera.position.x = 0;
  camera.position.z = 2;
  camera.position.y = 3;
  camera.lookAt(0, -1, 0);
  scene.add(camera);

  // SETUP ORBIT CONTROL OF THE CAMERA
  var controls = new THREE.OrbitControls(camera);
  controls.damping = 0.2;
  controls.noZoom = true;

  // ADAPT TO WINDOW RESIZE
  function resize() {
    renderer.setSize(window.innerWidth, window.innerHeight);
    camera.aspect = window.innerWidth / window.innerHeight;
    camera.updateProjectionMatrix();
  }

  window.addEventListener('resize', resize);
  resize();

  function loadOBJ(file, material, scale, xOff, yOff, zOff, xRot, yRot, zRot) {
    var onProgress = function(query) {
      if ( query.lengthComputable ) {
        var percentComplete = query.loaded / query.total * 100;
        console.log( Math.round(percentComplete, 2) + '% downloaded' );
      }
    };

    var onError = function() {
      console.log('Failed to load ' + file);
    };

    var loader = new THREE.OBJLoader();
    loader.load(file, function(object) {
      object.traverse(function(child) {
        if (child instanceof THREE.Mesh) {
          child.material = material;
        }
      });

      object.position.set(xOff,yOff,zOff);
      object.rotation.x = xRot;
      object.rotation.y = yRot;
      object.rotation.z = zRot;
      object.scale.set(scale,scale,scale);
      object.castShadow = true;
      object.receiveShadow = true;
      scene.add(object);

    }, onProgress, onError);
  }

  function createLight( color ) {

    var pointLight = new THREE.PointLight( color, 1, 30 );
    pointLight.castShadow = true;
    pointLight.shadowCameraNear = 1;
    pointLight.shadowCameraFar = 30;
    // pointLight.shadowCameraVisible = true;
    pointLight.shadowBias = 0.01;

    var geometry = new THREE.SphereGeometry( 0.3, 32, 32 );
    var material = new THREE.MeshBasicMaterial( { color: color } );
    var sphere = new THREE.Mesh( geometry, material );
    pointLight.add( sphere );

    return pointLight

  }

  pointLight = createLight( 0xffffff );
  pointLight.position.x = 0;
  pointLight.position.y = 2;
  pointLight.position.z = 3;
  scene.add( pointLight );

  var lightedMaterial = new THREE.MeshPhongMaterial( {
    color: 0xffffff,
    shininess: 50,
    specular: 0x222222
  });

  //var material = new THREE.MeshBasicMaterial({ color: 0xffffff });

  //loadOBJ('girl.obj', material, 1, 0,0,0, -3.14/2, 0, 3.14);
  loadOBJ(fileLoc, lightedMaterial, 1, 0,0,0, -3.14/2, 0, 3.14);
}

function update() {
  requestAnimationFrame(update);
  renderer.render(scene, camera);
}

update();
