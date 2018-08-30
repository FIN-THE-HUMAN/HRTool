import _ from 'lodash';
import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';
import { Label, Glyphicon, FormGroup, FormControl } from 'react-bootstrap';

import { VacancyStatuses } from '../constants/EnumsConstants';

class VacancyStatus extends Component {
  constructor(props) {
    super(props);

    const { status } = this.props;

    this.state = {
      editing: false,
      status
    };
  }

  handleToggleEditing = () => this.setState(prev => ({ editing: !prev.editing }));

  handleEdit = () => {
    const { status } = this.state;

    this.handleToggleEditing();
    this.props.onEdit(status);
  };

  cancelEdit = () => {
    const { status } = this.props;

    this.handleToggleEditing();
    this.setState({ status });
  };

  handleChange = ({ target }) => this.setState({ status: target.value });

  render() {
    const { status, editing } = this.state;

    const vacancyStatusType = _.find(VacancyStatuses, { name: status }).value;

    return (
      <div className="vacancy-status">
        {editing ?
          <Fragment>
            <FormGroup controlId="formControlsSelect" className="editing-field" bsSize="small">
              <FormControl
                value={this.state.status}
                componentClass="select"
                placeholder="select"
                onChange={this.handleChange}
              >
                {VacancyStatuses.map(({ value, name }) => (
                  <option key={value} value={name}>{name}</option>
                ))}
              </FormControl>
            </FormGroup>
            <Glyphicon glyph="ok" onClick={this.handleEdit} />
            <Glyphicon glyph="remove" onClick={this.cancelEdit} />
          </Fragment> :
          <Fragment>
            <Label className={`status status-${vacancyStatusType}`}>{status}</Label>
            <Glyphicon glyph="pencil" onClick={this.handleToggleEditing} />
          </Fragment>
        }
      </div>
    );
  }
}

VacancyStatus.propTypes = {
  status: PropTypes.string,
  onEdit: PropTypes.func,
};

export default VacancyStatus;
