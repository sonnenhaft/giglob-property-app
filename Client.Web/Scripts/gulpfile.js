var gulp = require('gulp');

var src = {
    js: 'app/**/*.js',
    scss: 'app/**/*.scss',
    css: 'app/**/*.css',
    buildCss: ['lib/**/*.css', 'app/**/*.css'],
    html: ['app/**/*.html', '!app/**/example/*.html'],
    img: ['Content/Images/**/*.svg', 'Content/Images/**/*.png', 'Content/Images/**/*.jpeg', 'Content/Images/**/*.jpg', 'Content/Images/**/*.ttf']
};

//LINT: RUN BEFORE PUSH
gulp.task('lint:css', function() {
    var csslint = require('gulp-csslint');
    var htmlReporter = require('gulp-csslint-report');
    
    return gulp.src(src.css)
        .pipe(csslint({
            'adjoining-classes': false,
            'box-sizing': false
        }))
        .pipe(csslint.reporter())
        .pipe(htmlReporter({
            filename: 'css-report.html',
            directory: 'resources/reports/'
        }))
});

gulp.task('lint:js', function() {
    var jshint = require('gulp-jshint');

    return gulp.src(src.js)
        .pipe(jshint())
        .pipe(jshint.reporter('jshint-stylish', {beep: true}))
        .pipe(jshint.reporter('gulp-jshint-html-reporter', {
            filename:  'resources/reports/js-report.html',
            createMissingFolders : true
        }))
});

//

gulp.task('connect:localhost', ['sass:reload'], function() {
    var browserSync = require('browser-sync');
    var reload = browserSync.reload;

    browserSync({
        server: './'
    });

    gulp.watch(src.scss, ['sass:reload']);
    gulp.watch(src.html).on('change', reload);
    gulp.watch(src.js).on('change', reload);
});

gulp.task('connect:build', function() {
    var browserSync = require('browser-sync');

    browserSync({
        server: '../'
    });

});

gulp.task('_serve', function () {
    var inject = require('gulp-inject');

    return gulp.src('resources/index.html')
        .pipe(inject(gulp.src([src.js, src.css], {read: false})))
        .pipe(gulp.dest('./'));
});

gulp.task('_serve:build', function () {
    var inject = require('gulp-inject');
    var rename = require('gulp-rename');

    return gulp.src('resources/index.html')
        .pipe(inject(gulp.src('dist/app.js', {read: false}), {addPrefix: '../Scripts', name: 'build', addRootSlash: false }))
        .pipe(inject(gulp.src( '../Content/styles/app.css', {read: false}), {name: 'build', addRootSlash: false }))
        .pipe(rename({extname: '.cshtml'}))
        .pipe(gulp.dest('../Views/'));
});


gulp.task('sass:compile', function () {
    var sass = require('gulp-sass');

    return gulp.src('app/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('app'));
});

gulp.task('sass:watch', function () {
    gulp.watch('app/**/*.scss', ['sass']);
});

gulp.task('sass:reload', function() {
    var sass = require('gulp-sass');
    var browserSync = require('browser-sync');
    var reload = browserSync.reload;

    return gulp.src(src.scss)
        .pipe(sass())
        .pipe(gulp.dest('app'))
        .pipe(reload({stream: true}));
});

gulp.task('bump', function(){
    var bump = require('gulp-bump');

    return gulp.src('./package.json')
        .pipe(bump({type:'patch'}))
        .pipe(gulp.dest('./'));
});

gulp.task('concat', function() {
    var concat = require('gulp-concat');
    
    return gulp.src([
        "lib/vendor/angular/angular.js",
        "lib/**/*.js",
        "app/**/*.js"
    ])
        .pipe(concat('app.js'))
        .pipe(gulp.dest('./dist/'));
});
gulp.task('concat:css', function () {
    var concatCss = require('gulp-concat-css');
    return gulp.src(src.buildCss)
        .pipe(concatCss('app.css'))
        .pipe(gulp.dest('../Content/styles'));
});
gulp.task('process:templates', function() {
    var ngHtml2Js = require("gulp-ng-html2js");

    gulp.src(src.html)
        .pipe(ngHtml2Js({
            moduleName: 'templates',
            rename: function (templateUrl, templateFile) {
                return 'app/' + templateUrl;
            }
        }))
        .pipe(gulp.dest('app/templates'));
});

gulp.task('minify:css', function() {
    var cleanCSS = require('gulp-clean-css');

    return gulp.src('../Content/styles/app.css')
        .pipe(cleanCSS())
        .pipe(gulp.dest('../Content/styles'));
});

gulp.task('uglify', function() {
    var uglify = require('gulp-uglify');

    return gulp.src('dist/app.js')
        .pipe(uglify())
        .pipe(gulp.dest('dist'));
});

gulp.task('annotate', function () {
    var ngAnnotate = require('gulp-ng-annotate');

    return gulp.src('dist/app.js')
        .pipe(ngAnnotate())
        .pipe(gulp.dest('dist'));
});

gulp.task('dev', function() {
    var runSequence = require('run-sequence');

    return runSequence('sass:compile', '_serve', 'connect:localhost');
});

gulp.task('move:img', function() {
    var rename = require('gulp-rename');

    return gulp.src(src.img)
        //.pipe(rename({dirname: ''}))
        .pipe(gulp.dest('../Content/Images/'));
});

gulp.task('move:package', function() {
    return gulp.src('package.json')
        .pipe(gulp.dest('dist'));
});

gulp.task('clean:css', function () {
    var clean = require('gulp-clean');

    return gulp.src('../Content/styles', {read: false})
        .pipe(clean({force: true}));
});

gulp.task('clean:index', function () {
    var clean = require('gulp-clean');

    return gulp.src('../Views/index.html', {read: false})
        .pipe(clean({force: true}));
});

gulp.task('clean:dist', function () {
    var clean = require('gulp-clean');

    return gulp.src('dist', {read: false})
        .pipe(clean());
});
gulp.task('clean:templates', function () {
    var clean = require('gulp-clean');

    return gulp.src('app/templates', {read: false})
        .pipe(clean());
});
gulp.task('build', function () {
    var runSequence = require('run-sequence');

    return runSequence('clean:dist', 'clean:css', 'clean:index', 'process:templates', 'sass:compile', 'concat:css', 'minify:css', 'concat', 'annotate', 'uglify', 'move:img', 'move:package', '_serve:build', 'clean:templates');
});