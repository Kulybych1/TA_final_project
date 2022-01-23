Feature: SpecFlowFeatureBBC
	Simple calculator for adding two numbers

@mytag
Scenario: checkTheFormWithValidInputData
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form is <passed>

	Examples: 
	| textData             | nameData | emailData                    | conyactNumberData | locationData | passed |
	| Here is my story sdf | Nick     | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         | true   |

@mytag
Scenario: checkTheFormWithInvalidTextareaInput
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form InvalidText assert <passed>

	Examples: 
	| textData | nameData | emailData                    | conyactNumberData | locationData | passed |
	|          | Nick     | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         | true   |

@mytag
Scenario: checkTheFormWithInvalidNameInput
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form InvalidName assert <passed>

	Examples: 
	| textData             | nameData | emailData                    | conyactNumberData | locationData | passed |
	| Here is my story sdf |          | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         | true   |

@mytag
Scenario: checkTheFormWithInvalidEmailInput
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form InvalidEmail assert <passed>

	Examples: 
	| textData             | nameData | emailData          | conyactNumberData | locationData | passed |
	| Here is my story sdf | Nick     | fjqgrezlevoopvwgpi | +3806723424       | Kyiv         | true   |

@mytag
Scenario: checkTheFormWithUncheckedTermsOfServiceCheckbox
	Given User goes to bbc Stories page
	When User enter data wirh unchecked box <textData> <nameData> <emailData> <conyactNumberData> <locationData> <check>
	Then User can see the form with UncheckedTermsOfServiceCheckbox assert <passed>

	Examples: 
	| textData             | nameData | emailData          | conyactNumberData | locationData | passed | check |
	| Here is my story sdf | Nick     | fjqgrezlevoopvwgpi | +3806723424       | Kyiv         | true   | false |

@mytag
Scenario: checkNameOfHeadlineArticle
	Given User goes to bbc Home page
	When User navigates to Main <link>
	Then User can see matcing articles <expectedHeadline>

	Examples: 
	| link                 | expectedHeadline                                   |
	| https://www.bbc.com/ | UK warns of plot to install Russia ally in Ukraine |


@mytag
Scenario: checkSecondaryArticlesTitles
	Given User goes to bbc covid news
	When User navigates to news <link>
	Then User see matcing articles <firstArticle> <secondArticle> <thirdArticle> <fourthArticle> <fifthArticle>

	Examples: 
	| link                                 | firstArticle                                      | secondArticle                                    | thirdArticle                                       | fourthArticle                                      | fifthArticle                                          |
	| https://www.bbc.com/news/coronavirus | WHO warns Covid not over amid Europe case records | Covid isolation cut to five full days in England | Beijing urges end to foreign deliveries over Covid | The puzzle of America's record Covid hospital rate | Banker who quit over Covid breach went to Euros final |