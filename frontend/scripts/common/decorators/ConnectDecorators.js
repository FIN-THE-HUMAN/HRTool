import _ from 'lodash';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

const defaultMapStateToProps = name => store => (
  _.isArray(name) ?
    _.reduce(name, (result, path) => ({ ...result, ..._.get(store, path) }), {}) :
    { ..._.get(store, name) }
);

const connectToStore = ({ mapStateToProps, name, actions }) => (
  connect(
    mapStateToProps ||
    (name && defaultMapStateToProps(name)),
    actions && (dispatch => ({ actions: bindActionCreators(actions, dispatch) }))
  )
);

export default connectToStore;
