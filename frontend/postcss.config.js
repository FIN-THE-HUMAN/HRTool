const autoprefixer = require('autoprefixer');

module.exports = {
  plugins: [
    autoprefixer({
      browsers: [
        'Firefox > 20',
        'Chrome > 20',
        'Explorer > 10',
        'Opera > 12',
        'Safari > 6',
        'iOS > 7'
      ]
    })
  ]
};
