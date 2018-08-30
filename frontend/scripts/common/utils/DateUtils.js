import moment from 'moment';
import 'moment/locale/ru';

export default {
  isMoment: moment.isMoment,
  moment,
  now: () => moment().startOf('day'),
};
