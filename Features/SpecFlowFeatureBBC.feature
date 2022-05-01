Feature: SpecFlowFeatureBBC
	Simple calculator for adding two numbers

@mytag
Scenario: checkTheFormWithValidInputData
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form passed

	Examples: 
	| textData                  | nameData | emailData                    | conyactNumberData | locationData |
	| Here is myss ssdftory sdf | Nick     | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         |

@mytag
Scenario: checkTheFormWithInvalidTextareaInput
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form InvalidText assert

	Examples: 
	| textData | nameData | emailData                    | conyactNumberData | locationData |
	|          | Nick     | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         |

@mytag
Scenario: checkTheFormWithInvalidNameInput
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form InvalidName assert

	Examples: 
	| textData             | nameData | emailData                    | conyactNumberData | locationData |
	| Here is my story sdf |          | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         |

@mytag
Scenario: checkTheFormWithInvalidEmailInput
	Given User goes to bbc Stories page
	When User enter the <textData> <nameData> <emailData> <conyactNumberData> <locationData>
	Then User can see the form InvalidEmail assert

	Examples: 
	| textData             | nameData | emailData          | conyactNumberData | locationData |
	| Here is my story sdf | Nick     | fjqgrezlevoopvwgpi | +3806723424       | Kyiv         | 

@mytag
Scenario: checkTheFormWithUncheckedTermsOfServiceCheckbox
	Given User goes to bbc Stories page
	When User enter data wirh unchecked box <textData> <nameData> <emailData> <conyactNumberData> <locationData> <acceptCheckbox>
	Then User can see the form with UncheckedTermsOfServiceCheckbox assert

	Examples: 
	| textData                   | nameData | emailData                    | conyactNumberData | locationData | acceptCheckbox |
	| Here is my story sdfgdgdfg | Nick     | fjqgrezlevoopvwgpi@nthrw.com | +3806723424       | Kyiv         | false           |

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
Given User goes to covid news
When User navigates via the <link>
Then User se articles "<topArticle>" "<underArticle>" "<positionTop>" "<positionUnder>"

Examples: 
| link                                 | topArticle                                      | underArticle                                    | positionTop | positionUnder |
| https://www.bbc.com/news/coronavirus | Long Covid: Hidden lung damage spotted on scans | Call to delay compulsory vaccines for NHS staff | 0           | 3             |
