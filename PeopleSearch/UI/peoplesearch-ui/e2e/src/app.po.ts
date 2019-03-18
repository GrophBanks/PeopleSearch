import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    //return browser.get(browser.baseUrl) as Promise<any>;
    return browser.driver.get('http://localhost:50940');
  }

  fillFormData(){
    element(by.id('txtFirstName')).sendKeys('Test');
    element(by.id('txtLastName')).sendKeys('Person');
    element(by.id('txtAddress')).sendKeys('123 Test St, Anywhere USA 90210');
    element(by.id('txtInterests')).sendKeys('Test Person enjoys filling out test data.');
  }

  clickAdd(){
    element(by.id('bttnAddPerson')).click();
  }

  getAddpersonMessage(){
    return element(by.id('spnAddPersonResponseMessage')).getText();
  }

  getValidationMessage(){
    return element(by.id('spnVaildationMessage')).getText();
  }

  clickSearchButton(){
    element(by.id('bttnSearch')).click();
  }

  addSearchTerm(searchTerm){
    element(by.id('txtLastNameSearch')).sendKeys(searchTerm);
  }

  getSearchResultCount(){
    let items = element.all(by.css('.searchResultsCard'));
    return items.count();
  }

  getSearchValidationMessage(){
    return element(by.id('spnSearchValidationMessage')).getText();
  }
}
