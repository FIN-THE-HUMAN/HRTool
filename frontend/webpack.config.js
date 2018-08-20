const { resolve } = require('path');
const webpack = require('webpack');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const HtmlWebPackPlugin = require('html-webpack-plugin');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');

const dist = resolve(__dirname, '..', 'dist');
const common = resolve(__dirname, 'scripts', 'common');

const devMode = process.env.NODE_ENV !== 'production';

const cssLoaders = [
  'resolve-url-loader',
  {
    loader: 'sass-loader',
    options: {
      sourceMap: true
    }
  }
];

if (!devMode) cssLoaders.unshift('css-loader', 'postcss-loader');
else cssLoaders.unshift('css-loader');

module.exports = {
  mode: devMode ? 'development' : 'production',
  entry: resolve('.', 'scripts', 'main', 'index.js'),
  output: {
    path: dist,
    publicPath: '/',
    filename: 'index.js'
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /(node_modules)/,
        loader: 'babel-loader'
      },
      {
        test: /\.(css|scss|sass)(\?.+)?$/,
        use: [
          MiniCssExtractPlugin.loader,
          ...cssLoaders
        ]
      },
      {
        test: /\.(png|jpe?g|gif|ico)(\?.+)?$/,
        loader: {
          loader: 'url-loader',
          query: {
            limit: 512,
            name: '[name].[ext]'
          }
        }
      },
      {
        test: /\.(otf|eot|svg|ttf|woff|woff2)(\?.+)?$/,
        loader: {
          loader: 'url-loader',
          query: {
            limit: 2048,
            name: '[name].[ext]'
          }
        }
      }
    ]
  },
  plugins: [
    new HtmlWebPackPlugin({
      template: './index.html',
      inject: false
    }),
    new MiniCssExtractPlugin({
      filename: 'index.css'
    }),
    new webpack.DefinePlugin({
      'process.env.NODE_ENV': JSON.stringify(process.env.NODE_ENV)
    })
  ],
  optimization: {
    minimizer: [
      new UglifyJsPlugin({
        cache: true,
        parallel: true,
        sourceMap: false
      }),
      new OptimizeCSSAssetsPlugin({})
    ]
  },
  resolve: {
    alias: {
      services: resolve(common, 'services'),
      utils: resolve(common, 'utils'),
      constants: resolve(common, 'constants'),
      containers: resolve(common, 'containers'),
      components: resolve(common, 'components'),
      decorators: resolve(common, 'decorators'),
      store: resolve(common, 'store')
    },
    extensions: ['.js', '.jsx', '.css', '.scss', '.sass']
  },
  devServer: {
    compress: true,
    historyApiFallback: true,
  }
};
