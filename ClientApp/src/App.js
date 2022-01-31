import React, { Component } from 'react';
import { Plats } from './components/Plats';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Plats/>
    );
  }
}
