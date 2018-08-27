const WindowService = {
  get location() {
    return window.location;
  },

  get origin() {
    return '/';
  },

  redirect(href) {
    window.location.href = href;
  },

  open(link) {
    window.open(link);
  }
};

export default WindowService;
