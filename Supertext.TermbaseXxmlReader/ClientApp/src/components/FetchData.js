import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = "Term base XML Reader";

  constructor(props) {
      super(props);
      this.state = { terms: [], loading: true, file: null };
  }

  componentDidMount() {
    }

    saveFile (e) {
        this.setState({ file: e.target.files[0]});
    };

    static renderTerms(terms) {
       

        return (

            <div className="term-container">
                {terms.map((termItem, index) =>
                    <div key={index} className="term-item">
                        {termItem.termLanguages.map((term, index) =>
                            <div>
                                <p className="language-name">
                                    {term.languageName}
                                    <br />
                                    {term.languageType}
                                </p>
                                <span className="term">{term.term}</span>
                                <br />
                                <br />
                                {term.additionalInformations.map(info =>
                                    <div>                                        
                                        {info.key}: {info.value}
                                        <br />
                                    </div>
                                )}
                                <hr />
                            </div>
                        )}
                       
                        <br />
                        <br />
                    </div>
                )}
               
            </div>
        )
    };

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
        ? <div>
            <input type="file" onChange={this.saveFile.bind(this)} />
            <input type="button" value="upload" onClick={this.uploadFile.bind(this)} />
        </div>
        : FetchData.renderTerms(this.state.terms);

    return (
      <div>
            <h1 id="tabelLabel">Termbase XML Reader</h1>
        <p>This component demonstrates fetching data from the server. Please upload XML file.</p>
        {contents}
      </div>
    );
  }

    async uploadFile() {
        if (typeof (this.state.file) == 'undefined' || this.state.file == null) {
            alert("Please select XML file");
            return;
        }
      const formData = new FormData();
      formData.append("xmlFile", this.state.file);
        try {
            fetch("termbasereader", {
                method: 'POST',
                headers: {
                    'Accept': 'application/json'
                },
                body: formData
            }).then((response) => {
                if (response.ok) {
                    response.json().then((result) => {
                        this.setState({ terms: result, loading: false });
                    });
                } else {
                    response.text().then((msg) => {
                        alert(msg);
                    });
                    
                }

        })
    } catch(ex) {
        console.log(ex);
    }
  }
}
