import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

const connectToStore = ({ name, actions }) => (
  connect(
    store => store[name],
    actions && (dispatch => ({ actions: bindActionCreators(actions, dispatch) }))
  )
);

export default connectToStore;
