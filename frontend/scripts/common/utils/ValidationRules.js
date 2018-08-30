const UrlRegex = /^(https?:\/\/)?([\w.]+)\.([a-z]{2,6}\.?)(\/[\w.]*)*\/?$/;

const required = value => (value ? null : 'Заполните это поле');

const positiveNumber = value => {
  if (!value) return null;

  if (isNaN(value) || value <= 0) return 'Значение должно быть положительным числом';

  return null;
};

const url = value => (UrlRegex.test(value) ? null : 'Значение должно быть url-адресом');

export { required, positiveNumber, url };
