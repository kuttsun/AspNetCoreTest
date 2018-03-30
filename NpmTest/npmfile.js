// see. https://www.linkedin.com/pulse/use-npm-instead-bower-gulp-grunt-visual-studio-aspnet-naghizadeh
process.once('beforeExit', function () {
    eval(process.argv[2]);
});

var fs = require('fs-extra')

function copyLib() {
    console.log("Copy node_modules to wwwroot/lib");
    //fs.mkdirsSync('piyo');
    //fs.copyRecursive('.node_modules/jquery/dist', './wwwroot/lib/jquery')
    //fs.copySync('npmfile.js', 'hoge.js');
    fs.copySync('node_modules', 'wwwroot/lib/');
}

function myTask() {
    consol.log("Hello World");
}