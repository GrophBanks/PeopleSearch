import { AppPage } from './app.po';
import { browser, logging } from 'protractor';
import { constants } from '../../src/app/constants';

describe('People search tests', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should add a new person', () => {
    page.navigateTo();
    page.fillFormData();
    page.clickAdd();

    expect(page.getAddpersonMessage()).toEqual(constants.AddUserSuccess);
  });

  it('should display validation message if required field is missing', function(){
    
    //click the add button without filling out any fields
    page.clickAdd();

    expect(page.getValidationMessage()).toEqual(constants.InputValidationMessage);
  });

  it('should return search results', function(){
    page.fillFormData();
    page.clickAdd();

    page.addSearchTerm('Person');
    page.clickSearchButton();

    expect(page.getSearchResultCount()).toBeGreaterThan(0);
  });

  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });
});
