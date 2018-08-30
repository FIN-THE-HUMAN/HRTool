import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { FormControl, FormGroup, Button, Row, Col } from 'react-bootstrap';

class SearchForm extends Component {
  constructor(props) {
    super(props);

    this.onSubmit = this.onSubmit.bind(this);
  }

  onSubmit(event) {
    event.preventDefault();
    this.props.onSearch(event.target.search.value);
  }

  render() {
    const { value } = this.props;

    return (
      <form
        className="search-input"
        onSubmit={this.onSubmit}
      >
        <FormGroup>
          <Row>
            <Col sm={8}>
              <FormControl
                type="text"
                placeholder="Поиск..."
                name="search"
                defaultValue={value}
              />
            </Col>
            <Col sm={4}>
              <Button block bsStyle="primary" type="submit">Поиск</Button>
            </Col>
          </Row>
        </FormGroup>
      </form>
    );
  }
}

SearchForm.propTypes = {
  value: PropTypes.string,
  onSearch: PropTypes.func
};

export default SearchForm;
