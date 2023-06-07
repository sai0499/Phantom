copy this file to the path "C:\Program Files\Adobe\Adobe Photoshop CS6 (64 Bit)\Presets\Scripts"

/*
// Load the required libraries
#include "json2.js"
#include "FileUtils.js"

// Define the input PSD file path
var psdFilePath = "/path/to/your/psd/file.psd";

// Define the output spritesheet path
var spritesheetPath = "/path/to/output/spritesheet.png";

// Define the output JSON data path
var jsonPath = "/path/to/output/spritesheet.json";

// Open the PSD file
var psdFile = File(psdFilePath);
var doc = open(psdFile);

// Set the ruler units to pixels
preferences.rulerUnits = Units.PIXELS;

// Get the number of layers in the document
var numLayers = doc.layers.length;

// Define the spritesheet size
var spritesheetWidth = 0;
var spritesheetHeight = 0;

// Create an array to hold the layer data
var layerData = [];

// Loop through each layer
for (var i = 0; i < numLayers; i++) {
    var layer = doc.layers[i];

    // Skip hidden layers
    if (!layer.visible) {
        continue;
    }

    // Get the layer bounds
    var bounds = layer.bounds;

    // Update the spritesheet dimensions
    spritesheetWidth = Math.max(spritesheetWidth, bounds[2].value);
    spritesheetHeight = Math.max(spritesheetHeight, bounds[3].value);

    // Save the layer data
    layerData.push({
        name: layer.name,
        x: bounds[0].value,
        y: bounds[1].value,
        width: bounds[2].value,
        height: bounds[3].value
    });
}

// Resize the document to fit the spritesheet dimensions
doc.resizeCanvas(spritesheetWidth, spritesheetHeight, AnchorPosition.TOPLEFT);

// Save the spritesheet as PNG
var spritesheetFile = new File(spritesheetPath);
var options = new PNGSaveOptions();
doc.saveAs(spritesheetFile, options);

// Save the layer data as JSON
var jsonData = JSON.stringify(layerData, null, 4);
var jsonFile = new File(jsonPath);
jsonFile.open("w");
jsonFile.write(jsonData);
jsonFile.close();

// Close the document
doc.close(SaveOptions.DONOTSAVECHANGES); */

if (documents.length > 0) 
{
	
	// --------------------------
	docRef = activeDocument;    
	var activeLayer = docRef.activeLayer;

	numLayers = docRef.artLayers.length; 	
	var cols = docRef.width;
	
 	var spriteX = docRef.width;
 	
	// put things in order
	app.preferences.rulerUnits = Units.PIXELS;
	
	// resize the canvas
 	newX = numLayers * spriteX;
 	
 	docRef.resizeCanvas( newX, docRef.height, AnchorPosition.TOPLEFT );
 	 	
	// move the layers around
 	for (i=0; i < numLayers; i++)
 	{ 	
 		docRef.artLayers[i].visible = 1;
 		
  		var movX = spriteX*i;
  		
 		docRef.artLayers[i].translate(movX, 0);
 		
  	}
}

