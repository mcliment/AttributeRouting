﻿Feature: Url Route Prefixes

Scenario: Generating prefixed routes
	# MVC
	Given I have registered the routes for the UrlRoutePrefixesController
	When I fetch the routes for the UrlRoutePrefixes controller's Index action
	Then the route url is "Prefix/Index"
	# Web API
	Given I have registered the routes for the HttpUrlRoutePrefixesController
	When I fetch the routes for the HttpUrlRoutePrefixes controller's Get action
	Then the route url is "ApiPrefix/Get"

Scenario: Generating prefixed routes when route urls specify a duplicate prefix
	# MVC
	Given I have registered the routes for the UrlRoutePrefixesController
	When I fetch the routes for the UrlRoutePrefixes controller's DuplicatePrefix action
	Then the route url is "Prefix/DuplicatePrefix"
	# Web API
	Given I have registered the routes for the HttpUrlRoutePrefixesController
	When I fetch the routes for the HttpUrlRoutePrefixes controller's DuplicatePrefix action
	Then the route url is "ApiPrefix/DuplicatePrefix"

Scenario: Generating absolute routes when a route prefix is defined
	# MVC
	Given I have registered the routes for the UrlRoutePrefixesController
	When I fetch the routes for the UrlRoutePrefixes controller's Absolute action
	Then the route url is "PrefixAbsolute"
	# Web API
	Given I have registered the routes for the HttpUrlRoutePrefixesController
	When I fetch the routes for the HttpUrlRoutePrefixes controller's Absolute action
	Then the route url is "ApiPrefixAbsolute"

Scenario: Generating prefixed routes when route url starts with the route prefix
	# MVC
	Given I have registered the routes for the UrlRoutePrefixesController
	When I fetch the routes for the UrlRoutePrefixes controller's RouteBeginsWithRoutePrefix action
	Then the route url is "Prefix/Prefixer"
	# Web API
	Given I have registered the routes for the HttpUrlRoutePrefixesController
	When I fetch the routes for the HttpUrlRoutePrefixes controller's RouteBeginsWithRoutePrefix action
	Then the route url is "ApiPrefix/ApiPrefixer"

Scenario: Generating prefixed routes when ignoring the route prefix
	# MVC
	Given I have registered the routes for the UrlRoutePrefixesController
	When I fetch the routes for the UrlRoutePrefixes controller's NoPrefix action
	Then the route url is "NoPrefix"
	# Web API
	Given I have registered the routes for the HttpUrlRoutePrefixesController
	When I fetch the routes for the HttpUrlRoutePrefixes controller's NoPrefix action
	Then the route url is "NoApiPrefix"

Scenario: Generating prefixed area routes
	# MVC
	Given I have registered the routes for the AreaRoutePrefixesController
	When I fetch the routes for the AreaRoutePrefixes controller's Index action
	Then the route url is "Area/Prefix/Index"
	# Web API
	Given I have registered the routes for the HttpAreaRoutePrefixesController
	When I fetch the routes for the HttpAreaRoutePrefixes controller's Get action
	Then the route url is "ApiArea/ApiPrefix/Get"
	
Scenario: Generating prefixed area routes when route urls specify a duplicate prefix
	# MVC
	Given I have registered the routes for the AreaRoutePrefixesController
	When I fetch the routes for the AreaRoutePrefixes controller's DuplicatePrefix action
	Then the route url is "Area/Prefix/DuplicatePrefix"
	# Web API
	Given I have registered the routes for the HttpAreaRoutePrefixesController
	When I fetch the routes for the HttpAreaRoutePrefixes controller's DuplicatePrefix action
	Then the route url is "ApiArea/ApiPrefix/DuplicatePrefix"

Scenario: Generating absolute routes when a route area and route prefix is defined
	# MVC
	Given I have registered the routes for the AreaRoutePrefixesController
	When I fetch the routes for the AreaRoutePrefixes controller's Absolute action
	Then the route url is "AreaPrefixAbsolute"
	# Web API
	Given I have registered the routes for the HttpAreaRoutePrefixesController
	When I fetch the routes for the HttpAreaRoutePrefixes controller's Absolute action
	Then the route url is "ApiAreaPrefixAbsolute"
	
Scenario: Generating routes when a route area and route prefix are defined and the action respecifies the area url
	# MVC
	Given I have registered the routes for the AreaRoutePrefixesController
	When I fetch the routes for the AreaRoutePrefixes controller's RelativeUrlIsAreaUrl action
	Then the route url is "Area/Prefix/Area"
	# Web API
	Given I have registered the routes for the HttpAreaRoutePrefixesController
	When I fetch the routes for the HttpAreaRoutePrefixes controller's RelativeUrlIsAreaUrl action
	Then the route url is "ApiArea/ApiPrefix/ApiArea"

Scenario: Generating routes with the default ctor of the UrlRoutePrefixAttribute
	# MVC
	Given I have registered the routes for the DefaultRoutePrefixController
	When I fetch the routes for the DefaultRoutePrefix controller's Index action
	Then the route url is "DefaultRoutePrefix/Index"
	# Web API
	Given I have registered the routes for the HttpDefaultRoutePrefixController
	When I fetch the routes for the HttpDefaultRoutePrefix controller's Get action
	Then the route url is "HttpDefaultRoutePrefix/Index"

Scenario: Generating prefixed routes when specifying multiple route prefixes
	# MVC
	Given I have registered the routes for the MultipleRoutePrefixController
	When I fetch the routes for the MultipleRoutePrefix controller's Index action
	Then the 1st route url is "FirstPrefix/Index"
	And the 3rd route url is "SecondPrefix/Index"
	# Web API
	Given I have registered the routes for the HttpMultipleRoutePrefixController
	When I fetch the routes for the HttpMultipleRoutePrefix controller's Get action
	Then the 1st route url is "HttpFirstPrefix/Index"
	And the 2st route url is "HttpSecondPrefix/Index"
