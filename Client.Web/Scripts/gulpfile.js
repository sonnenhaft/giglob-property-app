var gulp = require('gulp');

var src = {
    js: 'app/**/*.js',
    scss: 'app/**/*.scss',
    css: 'app/**/*.css',
    html: 'app/**/*.html'
};

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

gulp.task('_serve', function () {
    var inject = require('gulp-inject');

    return gulp.src('resources/index.html')
        .pipe(inject(gulp.src([src.js, src.css], {read: false})))
        .pipe(gulp.dest('./'));
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


gulp.task('dev', function() {
    var runSequence = require('run-sequence');

    return runSequence('sass:compile', '_serve', 'connect:localhost');
});