import _ from 'lodash';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Pagination from 'react-bootstrap/lib/Pagination';

const MAX_BUTTONS = 3;

class ControlsPagination extends Component {
  constructor(props) {
    super(props);

    this.onCountChange = count => () => props.onCountChange(count);
    this.onPageChange = this.onPageChange.bind(this);
  }

  componentWillReceiveProps({ total, offset, count }) {
    if (total && total === offset) {
      this.onPageChange(total / count);
    }
  }

  onPageChange(page, event) {
    if (event) event.preventDefault();

    const { offset, total, count, onPageChange } = this.props;
    const newOffset = (page * count) - count;

    if (newOffset !== offset && newOffset >= 0 && newOffset < total) {
      onPageChange(newOffset, page, event);
    }
  }

  renderCounts() {
    const { counts, count, total } = this.props;

    if (counts.length < 2 || _.head(counts) >= total) return null;

    return (
      <div className="counts">
        {counts.map((item, id) => (
          <button
            key={id}
            className={item === count ? 'is-selected' : ''}
            onClick={this.onCountChange(item)}
          >
            {item}
          </button>
        ))}
      </div>
    );
  }

  renderPages() {
    const { offset, total, count } = this.props;
    const buttons = Math.ceil(total / count);

    if (buttons < 2) return null;

    const activePage = offset > 0 ? (offset / count) + 1 : 1;
    const maxButtons = buttons < MAX_BUTTONS ? buttons : MAX_BUTTONS;

    const items = [];
    const sidePages = Math.ceil((maxButtons - 1) / 2);
    const minPage = Math.max(activePage - sidePages, 2);
    const maxPage = Math.min(activePage + sidePages, buttons - 1);

    for (let page = minPage; page <= maxPage; page += 1) {
      items.push(
        <Pagination.Item
          active={page === activePage}
          onClick={() => this.onPageChange(page)}
          key={page}
        >
          {page}
        </Pagination.Item>
      );
    }

    return (
      <Pagination>
        <Pagination.First onClick={() => this.onPageChange(1)} />
        <Pagination.Prev onClick={() => this.onPageChange(activePage - 1)} />
        <Pagination.Item
          active={activePage === 1}
          onClick={() => this.onPageChange(1)}
        >
          {1}
        </Pagination.Item>
        {activePage - sidePages > 2 &&
          <Pagination.Ellipsis onClick={() => this.onPageChange(activePage - 2)} />
        }
        {items}
        {activePage + sidePages < buttons - 1 &&
          <Pagination.Ellipsis onClick={() => this.onPageChange(activePage + 2)} />
        }
        <Pagination.Item
          active={activePage === buttons}
          onClick={() => this.onPageChange(buttons)}
        >
          {buttons}
        </Pagination.Item>
        <Pagination.Next onClick={() => this.onPageChange(activePage + 1)} />
        <Pagination.Last onClick={() => this.onPageChange(buttons)} />
      </Pagination>
    );
  }

  render() {
    return (
      <div className="controls-pagination">
        {this.renderPages()}
        {this.renderCounts()}
      </div>
    );
  }
}

ControlsPagination.propTypes = {
  offset: PropTypes.number,
  count: PropTypes.number.isRequired,
  counts: PropTypes.array,
  total: PropTypes.number.isRequired,
  onPageChange: PropTypes.func.isRequired,
  onCountChange: PropTypes.func.isRequired
};

export default ControlsPagination;
